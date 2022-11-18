using System.Collections.Generic;

namespace ClassLibrary1_Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<SubCategory> SubCategorys { get; set; }
    }
}
