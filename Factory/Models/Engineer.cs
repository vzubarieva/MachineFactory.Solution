using System.Collections.Generic;

namespace Factory.Models
{
    public class Engineer
    {
        public Restaurant()
        {
            this.Cuisines = new HashSet<Cuisine>();
        }

        public int RestaurantId { get; set; }
        public string Name { get; set; }

        public int MichelinStars { get; set; }
        public virtual ICollection<Cuisine> Cuisines { get; set; }
    }
}
