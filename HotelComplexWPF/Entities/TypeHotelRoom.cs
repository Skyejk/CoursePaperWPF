//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelComplexWPF.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeHotelRoom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeHotelRoom()
        {
            this.HotelRoom = new HashSet<HotelRoom>();
        }
    
        public int ID { get; set; }
        public string TypeName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelRoom> HotelRoom { get; set; }
    }
}
