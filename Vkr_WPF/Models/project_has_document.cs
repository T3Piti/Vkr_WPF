//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vkr_WPF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class project_has_document
    {
        public int id { get; set; }
        public int project_id { get; set; }
        public int document_id { get; set; }
        public Nullable<int> stage_id { get; set; }
        public int status_id { get; set; }
    
        public virtual document document { get; set; }
        public virtual documents_status documents_status { get; set; }
        public virtual project project { get; set; }
        public virtual stage stage { get; set; }
    }
}
