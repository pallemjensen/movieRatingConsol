using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks.Sources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace movieRatingConsol
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            int NumberOfEntries = 0;                

            IEnumerable<MovieRating> List;

            using (StreamReader r = new StreamReader("C:\\Users\\pmj74\\Documents\\movieRating\\sdm_movie_rating\\ratingsMini.json"))
            {
                string jsonString = r.ReadToEnd();

                List = JsonConvert.DeserializeObject<List<MovieRating>>(jsonString);

                NumberOfEntries = List.Count();

                Dictionary<int, object> _subMoviedictionary = new Dictionary<int, object>();
                Dictionary<int, object> _subReviewerdictionary = new Dictionary<int, object>();
                Dictionary<int, object> _subGradedictionary = new Dictionary<int, object>();
                Dictionary<int, DateTime> _subDatedictionary = new Dictionary<int, DateTime>();

                for (int i = 0; i < NumberOfEntries; i++)
                {
                    _subMoviedictionary.Add(i, List.ElementAt(i).Movie);
                    _subReviewerdictionary.Add(i, List.ElementAt(i).Reviewer);
                    _subGradedictionary.Add(i, List.ElementAt(i).Grade);
                    _subDatedictionary.Add(i, List.ElementAt(i).Date);
                    //Console.WriteLine(_subMoviedictionary.Values.ElementAt(i));
                    //Console.WriteLine(_subReviewerdictionary.Values.ElementAt(i));
                    //Console.WriteLine(_subGradedictionary.Values.ElementAt(i));
                    //Console.WriteLine(_subDatedictionary.Values.ElementAt(i));
                   // Console.WriteLine("-----");
                }

                foreach (var item in _subMoviedictionary.OrderBy(kvp => kvp.Value).ThenByDescending(kvp => kvp.Key)
                    .Select(kvp => kvp.Key).AsParallel().AsOrdered())
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();


                //var values = JObject.FromObject(MovieRating).ToObject<Dictionary<int, object>>();

                //foreach (KeyValuePair<int, object> kvp in _subMoviedictionary)
                //{
                //    Console.WriteLine(kvp.Value.ToString());
                //}

                //var _values = _dictionary.ElementAt(2);

                //Console.WriteLine(_values);

                //var result = _dictionary.AsParallel().Select(i => i.Value).Cast<Dictionary<int, Object>>()
                //    .Where(i => i.ContainsKey(1));

                //int counter = 0;

                //foreach (KeyValuePair<int, object> kvp in _dictionary)
                //{
                //    counter++;
                //    _dictionary.Add(counter, List.ElementAt(counter));
                //    Console.WriteLine(_dictionary.ElementAt(counter));
                //}

                var _values = (from list in List where list.Reviewer == 1 select list.Movie).AsParallel().Count();

                //for (int i = 0; i < NumberOfEntries; i++)
                //{
                //    _values.Select(List.ElementAt(i).Reviewer, List.ElementAt(i).Movie);
                //}

                //_dictionary
                //    .AsParallel()
                //    .ForAll(pair =>
                //    {
                //        // Process pair.Key and pair.Value here
                //    });
            }
        }
    }
}
