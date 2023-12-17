//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForeignLanguagesSchoolApp.model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.ClientService = new HashSet<ClientService>();
            this.Tag = new HashSet<Tag>();
        }

        public string ImgPath
        {
            get
            {
                var path = "pack://application:,,,/images/" + this.PhotoPath;
                return path;
            }
        }
        public List<Tag> TagList
        {
            get
            {
                return this.Tag.ToList();
            }
        }
        public string CountService
        {
            get
            {
                return this.ClientService.Count.ToString();

            }
        }

        public System.DateTime DateService
        {
            get
            {
                using (ForeignLanguagesSchoolEntities db = new ForeignLanguagesSchoolEntities())
                {
                    return db.ClientService
                             .Where(c => c.ClientID == this.ID)
                             .OrderByDescending(c => c.StartTime)
                             .Select(c => c.StartTime)
                             .FirstOrDefault();
                }
            }
        }
        public int GenderList
        {
            get
            {
                return Convert.ToInt32(this.GenderCode) - 1; ;
            }
        }
        public List<ClientService> ServiceList
        {
            get
            {
                return this.ClientService.ToList();
            }
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string GenderCode { get; set; }
        public string Phone { get; set; }
        public string PhotoPath { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Email { get; set; }
        public System.DateTime RegistrationDate { get; set; }
    
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientService> ClientService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tag { get; set; }
    }
}