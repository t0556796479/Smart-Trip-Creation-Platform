using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Entities
{
    public class AgendaStepDto
    {
        //זהו אוביקט  שמייצג נקודה בסדר היום שבלקוח בחר
        public int Id { get; set; }

        //CategoryId - הקטגוריה שאליה משתיכת הנקודה
        public int CategoryId { get; set; }

        //propertiesIdList - רשימת הקודים של המאפינים של הנקודה כאשר הקוד הראשון הוא המאפין של הפילטר וכל השאר הם הקודים של המאפינים הנוספים 
        public List<int> propertiesIdList { get; set; }

        public string filterName { get; set; }
        public string propertyName { get; set; }
    }
}
