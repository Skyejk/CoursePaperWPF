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
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.ReservationHotelRoom = new HashSet<ReservationHotelRoom>();
        }
    
        public int ID { get; set; }
        public int DetailedInformationAboutThePersonID { get; set; }
        public byte Blacklist { get; set; }
        public string Survey { get; set; }
        public string DescriptionNotes { get; set; }
    
        public virtual DetailedInformationAboutThePerson DetailedInformationAboutThePerson { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationHotelRoom> ReservationHotelRoom { get; set; }
    }
}
