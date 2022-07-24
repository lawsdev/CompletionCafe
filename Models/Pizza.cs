    using System.Collections.Generic;  
    using System.ComponentModel;    
    using System.Web.MVC;

        public class SubjectModel  
        {  
            public SubjectModel()  
            {  
                SubjectList = new List<SelectListItem>();  
            }  
      
            [DisplayName("Subjects")]  
            public List<SelectListItem> SubjectList  
            {  
                get;  
                set;  
            }  
        }  
    