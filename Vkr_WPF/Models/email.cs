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
    
    public partial class email
    {
        public int id { get; set; }
        public string email1 { get; set; }
        public int user_info_id { get; set; }
    
        public virtual users_info users_info { get; set; }
    }
}
