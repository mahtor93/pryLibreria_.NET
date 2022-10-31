using System.Collections.Generic;

namespace pryBookstore.Models.ViewModels
{
    public class ListBookViewModel
    {
        public List<Category> categoriesVM { get; set; }
        public List<Book> booksVM { get; set; }
    }
}
