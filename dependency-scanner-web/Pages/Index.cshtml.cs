using CHDepViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CHDepViewer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<SearchResult> _searchResults = new List<SearchResult>();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string dependency)
        {
            BuildSearchResults(dependency);   
        }

        private void BuildSearchResults(string dependency)
        {
            var searchTerm = dependency;

            Console.WriteLine("Search Term: " + searchTerm + " on Date: " + DateTime.Now.ToShortTimeString());

            if (String.IsNullOrEmpty(searchTerm))
                return;

            try
            {



                int counter = 0;

                foreach (var x in System.IO.Directory.GetFiles("Deps", "*.*", System.IO.SearchOption.AllDirectories))
                {

                    FileInfo fi = new FileInfo(x);

                    var fileData = System.IO.File.ReadAllText(x);



                    if (fileData.ToLower().Contains(searchTerm.ToLower()))
                    {
                        counter++;
                        //Console.WriteLine("Found: " + counter);
                        //Annoate the fileData

                        foreach (var word in fileData.Split(" "))
                        {
                            if (word.ToLower().Contains(searchTerm.ToLower()))
                            {
                                var newWord = $"<span style='background-color:yellow; font-weight:bold;'>{word}</span>";
                                fileData = fileData.Replace(word, newWord);

                            }
                        }
                        _searchResults.Add(new SearchResult()
                        {
                            DependencyTree = fileData,
                            Repository = fi.DirectoryName.Substring(fi.DirectoryName.LastIndexOf("\\") + 1)
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EX: " + ex.Message);
            }
        }

        public void OnPost()
        {
           
        }
    }
}
