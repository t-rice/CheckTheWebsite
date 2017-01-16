using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace сheckTheWebsite
{
    public static class extWebFunction
    {
        private static HtmlNodeCollection SafeSelectNodes(this HtmlNode node, string selector)
        {
            return (node.SelectNodes(selector) ?? new HtmlNodeCollection(node));
        }
        private static string formatLineBreaks(string webData)
        {
            string res;
            webData=webData.Replace("\r", " ").Replace("\n", " ").Replace("<", " <").Replace(">", "> ");
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(webData);

            foreach (HtmlNode node in htmlDoc.DocumentNode.SafeSelectNodes("//comment() | //script | //style | //head"))
            {
                node.ParentNode.RemoveChild(node);
            }
            //res = htmlDoc.DocumentNode.InnerText.Trim(); // Дебаг
            /*foreach (HtmlNode node in htmlDoc.DocumentNode.SafeSelectNodes("//span | //label")) // Удаляет лишнее
            {
                node.ParentNode.ReplaceChild(HtmlNode.CreateNode(node.InnerHtml), node);
            }*/
            //res = htmlDoc.DocumentNode.InnerText.Trim(); // Дебаг

            foreach (HtmlNode node in htmlDoc.DocumentNode.SafeSelectNodes("//p | //div"))
            {
                var txtNode = node.SelectSingleNode("text()");

                if (txtNode == null || txtNode.InnerHtml.Trim() == "") continue;

                node.ParentNode.InsertBefore(htmlDoc.CreateTextNode("\r\n"), node);
                node.ParentNode.InsertAfter(htmlDoc.CreateTextNode("\r\n"), node);
            }
            // res = htmlDoc.DocumentNode.InnerText.Trim(); // Дебаг

            foreach (HtmlNode node in htmlDoc.DocumentNode.SafeSelectNodes("//br"))
                node.ParentNode.ReplaceChild(htmlDoc.CreateTextNode("\r\n"), node);

            // Копируем полученный текст в строку
            res = htmlDoc.DocumentNode.InnerText.Trim();
            res = Regex.Replace(res, @"^\s*$", " ", RegexOptions.Multiline); // Регулярными выражениями удаляем все лишние символы
            res = res.ToLower();
            return res.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "); // Удаляем все лишние спец. символы и возвращаем строку
        }

        public static string analisWebSite(string webUrl, int analisDepth)
        {
            // Алгоритм обхода сайта в ширину (BFS) c нужной глубиной по всем категориям
            int countAllWord = 0;
            DateTime start = DateTime.Now;
            var webRes = bfsWebPages(webUrl, analisDepth,ref countAllWord);
            // Обработка полученных данных
            return createDepart(ref webRes, analisDepth, countAllWord, webUrl, start);
        }

        private static string giveDataPage(string webUrl)
        {
            string res;

            try           
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                StreamReader reader = new StreamReader(response.GetResponseStream());
                res = reader.ReadToEnd();
            }
            catch
            {
                res = "";
            }

            /*try
            { // БОЛЕЕ МЕДЛЕННЫЙ МЕТОД!
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Encoding = Encoding.UTF8;
                res = wc.DownloadString(webUrl);
            }
            catch
            {
                res =  ""; 
            }*/
            return res;
        }

        private static List<string> giveCategoryFromDB()
        {
            List<string> res = new List<string>();
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\keyWords.accdb";
            try
            {
                OleDbConnection myConn = new OleDbConnection(conString);
                myConn.Open();
                OleDbCommand Cmd = new OleDbCommand("Select Категория from Category", myConn); 
                OleDbDataReader ObjReader = Cmd.ExecuteReader();
                if (ObjReader != null)
                {
                    while (ObjReader.Read())
                    {
                        Cmd = new OleDbCommand("Select Count(*) from keyWord where Категория = '" + ObjReader.GetString(0)+"'", myConn);
                        OleDbDataReader countkeyWord = Cmd.ExecuteReader();
                        if (countkeyWord.Read() && countkeyWord.GetInt32(0) >= 10)
                            res.Add(ObjReader.GetString(0));
                    }
                }
                ObjReader.Close();
                myConn.Close();
            }catch
            {
                MessageBox.Show("Мы не смогли получить список категорий из базы данных, проверьте её наличие и попробуйте ещё раз.", "Ошибка базы данных", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
            }
            return res;
        }

        private static DataRow[] giveCategoryWordDB(string category, string table)
        {
            formCheckWeb fCheckWeb = new formCheckWeb();
            if(table == "keyWord")
                fCheckWeb.keyWordTableAdapter1.Fill(fCheckWeb.keyWordsDataSet1.keyWord);
            else
                fCheckWeb.aKeyWordTableAdapter1.Fill(fCheckWeb.keyWordsDataSet1.aKeyWord);
            return fCheckWeb.keyWordsDataSet1.Tables[table].Select("Категория = " + "\'" + category + "\'");
        }

        private static List<string> giveUrlInPage(ref string webData, string parrentWebUrl)
        {
            List<string> res = new List<string>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(webData);

            if (doc.DocumentNode.SelectNodes("//a[@href]")==null)
                return res;

            foreach(HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (att.Value.Contains(parrentWebUrl))
                {
                    if (!att.Value.EndsWith("/"))
                        att.Value += '/';
                    res.Add(att.Value);
                }
                else if (att.Value.IndexOf('/')==0)
                {
                    res.Add(parrentWebUrl + att.Value.Substring(1));
                }
            }
            return res;
        }

        private static Tuple<int, string, List<Tuple<double, string>>> createAnalisPage(string webUrl, ref string webData, string category)
        {
            DataRow[] catWords = giveCategoryWordDB(category,"keyWord");
            int countKeyWord = 0;
            double countW = countWord(webData);
            List<Tuple<double, string>> preRes = new List<Tuple<double, string>>();
            foreach (DataRow row in catWords)
            {
                string s = row["Ключевое слово/фраза"].ToString();
                int countFind = Regex.Matches(webData, s).Count;
                countKeyWord += countFind;
                preRes.Add(Tuple.Create<double, string>(countFind / countW, s));
            }
            preRes.Sort();
            preRes.Reverse();
            return Tuple.Create(countKeyWord, webUrl, preRes);
        }

        private static SortedDictionary<string, List<Tuple<int, string, List<Tuple<double, string>>>>> bfsWebPages(string webUrl, int analisDepth, ref int countAllWord)
        {
            SortedDictionary<string, List<Tuple<int, string, List<Tuple<double, string>>>>> res = new SortedDictionary<string, List<Tuple<int, string, List<Tuple<double, string>>>>>();
            // Сортированное перечисление по каждой категории, внутри каждой категории:
            // Массив для каждой страницы сайта
            // Содержит URL, число слов, массив количества встречаемых ключевых слов/фраз

            Queue<Tuple<int, string>> q = new Queue<Tuple<int, string>>(); // Очередь обхода в ширину Очередь(глубина захода, ссылка)
            q.Enqueue(Tuple.Create<int, string>(0,webUrl));
            SortedDictionary<string, bool> used = new SortedDictionary<string, bool>(); // Массив уже использованных ссылок
            used[webUrl] = true;            

            // Получаем список категорий
            List<string> category = giveCategoryFromDB();
            if(category.Count==0)
                return res;
            for (int i = 0; i < category.Count; ++i) // Готовим анализ по странице по всем категориям
                res.Add(category[i], new List<Tuple<int, string, List<Tuple<double, string>>>>());

            while (q.Count != 0)
            {
                Tuple<int, string> v = q.Dequeue();          // Помещаем первую в очереди веб-страницу в переменную, удаляя её из очереди

                string webData = giveDataPage(v.Item2);  // Получаем код страницы
                if (webData == "") // Если страницу не удалось загрузить по каким-то причинам
                    continue;

                List<string> nextPage = new List<string>();

                if (analisDepth != 0 && v.Item1 < Settings.Default.depthAnalis)                                    // Если анализ не быстрый
                    nextPage = giveUrlInPage(ref webData, webUrl);   // Собираем все ссылки куда ведет страница

                webData = formatLineBreaks(webData); // Удаляем все лишнее со страницы: теги, ссылки, скрипты, стили
                for (int i = 0; i < category.Count; ++i) // Готовим анализ по странице по всем категориям
                    res[category[i]].Add(createAnalisPage(v.Item2, ref webData, category[i]));
                countAllWord += countWord(webData);
                
                for(int i=0;i<nextPage.Count;++i)           // Обходим все ссылки, собранные ранее
                {
                    if (!used.ContainsKey(nextPage[i]) && v.Item1 < Settings.Default.depthAnalis)
                    {
                        q.Enqueue(Tuple.Create<int, string>(v.Item1+1,nextPage[i]));
                        used[nextPage[i]]=true;
                    }                
                }
            }
            return res;
        }
        
        private static int countWord(string text)
        {
            int wordCount = 0, index = 0;
            while (index < text.Length)
            {
                while (index < text.Length && !char.IsWhiteSpace(text[index]))
                    index++;
                wordCount++;
                while (index < text.Length && char.IsWhiteSpace(text[index]))
                    index++;
            }
            return wordCount;
        }

        private static string createDepart(ref SortedDictionary<string, List<Tuple<int, string, List<Tuple<double, string>>>>> resData, int analisDepth, int countAllWord, string webUrl, DateTime startTime)
        {
            string res = "ОТЧЕТ ПО САЙТУ(части сайта) " + webUrl;
            List<string> category = giveCategoryFromDB();

            for (int i = 0; i < category.Count; ++i)
            {
                res += Environment.NewLine+Environment.NewLine+"Категория \"" + category[i] + "\":" + Environment.NewLine;
                List<Tuple<int, string, List<Tuple<double, string>>>> inCategory = resData[category[i]];
                inCategory.Sort();      // Сортируем массив структурированных данных с веб-страниц
                inCategory.Reverse();   // Реверсим массив, чтобы сайты с многочисленными вхождениями ключевых слов оказались в начале
                int countCheckOk = 0;
                for (int j = 0; j < inCategory.Count; ++j)
                {
                    countCheckOk += checkAnalisWord(inCategory[j].Item3);
                }

                if (countCheckOk * 100.0 / inCategory.Count >= Settings.Default.minPercentCheckPage)
                {
                    // ПЛОХОЙ САЙТ
                    if (analisDepth > 0) // Глубокий анализ
                    {
                        res += "Сайт СОДЕРЖИТ контент категории \"" + category[i] + "\"." + Environment.NewLine + "Частотный анализ с глубиной " + analisDepth + " дал положительный результат для сайта." + Environment.NewLine;
                        res += "Было проверено " + inCategory.Count + " страниц сайта, при этом " + countCheckOk + " страниц содержат опасный контент"+Environment.NewLine;
                        res += "Например," + Environment.NewLine;
                        for (int k = 0; k < Math.Min(countCheckOk,Settings.Default.countProf); ++k)
                        {
                            res += "Страница " + inCategory[k].Item2 + " содержит опасный контент по категории \"" + category[i] + "\". Самое частоупотребимое слово: \"" + inCategory[k].Item3[0].Item2 + "\"." + Environment.NewLine;
                        }
                    }
                    else // Быстрый анализ
                    {
                        res += "Сайт вероятнее всего ПОДХОДИТ под категорию " + category[i] + "." + Environment.NewLine + "Частотный анализ дал положительный результат для страницы." + Environment.NewLine + "Советуем провести полный анализ сайта.";
                    }
                }
                else
                {
                    // ХОРОШИЙ САЙТ
                    if (analisDepth > 0) // Глубокий анализ
                    {
                        res += "Сайт НЕ содержит контент категории \"" + category[i] + "\"." + Environment.NewLine + "Частотный анализ с глубиной " + analisDepth + " дал отрицательный результат для сайта." + Environment.NewLine;
                        res += "Было проверено " + inCategory.Count + " страниц сайта, при этом " + countCheckOk + " страниц содержат опасный контент" + Environment.NewLine;
                    }
                    else // Быстрый анализ
                    {
                        res += "Сайт вероятнее всего НЕ подходит под категорию " + category[i] + "."+Environment.NewLine+"Частотный анализ дал отрицательный результат для страницы сайта.";
                    }
                }                
            }
            res += Environment.NewLine + Environment.NewLine + "Всего проверено слов " + countAllWord + "." + Environment.NewLine;
            TimeSpan timeRes = (DateTime.Now - startTime);
            res += "Затрачено времени: " + (timeRes.Days.ToString() != "0" ? timeRes.Days.ToString() + "д:" : "") + timeRes.Hours + "ч:" + timeRes.Minutes + "м:" + timeRes.Seconds + "с.";

            return res;
        }

        private static int checkAnalisWord(List<Tuple<double, string>> countWord) // ПРОВЕРКА ЧАСТОТЫ ВСТРЕЧИ СЛОВ ИЗ БАЗЫ!
        {
            double minFreqValue = Settings.Default.minFreqValue;
            double greatFreqValue = Settings.Default.greatFreqValue;
            double estimatedMinFreq = Settings.Default.estimateMinFreq * countWord.Count / 100;     // % от общей массы
            double estimatedGreatFreq = Settings.Default.estimateGreatFreq * countWord.Count / 100;   // % от общей массы

            int countMinFreq = 0, countGreatFreq = 0;
            for (int i = 0; i < countWord.Count; ++i)
            {
                countMinFreq += countWord[i].Item1 > minFreqValue ? 1 : 0;
                countGreatFreq += countWord[i].Item1 > greatFreqValue ? 1 : 0;
            }
            if (countMinFreq > estimatedMinFreq && countGreatFreq > estimatedGreatFreq)
                return 1;
            return 0;
        }
    }
}
