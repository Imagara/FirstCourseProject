//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kusach
{
    using System;
    using System.Collections.Generic;
    
    public partial class RouteList
    {
        public int Id { get; set; }
        public int IdRoute { get; set; }
        public int IdDispatcher { get; set; }
    
        public virtual Routes Routes { get; set; }
        public virtual Dispatcher Dispatcher { get; set; }
    }
}
