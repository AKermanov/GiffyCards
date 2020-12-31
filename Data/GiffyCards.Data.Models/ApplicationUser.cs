// ReSharper disable VirtualMemberCallInConstructor
namespace GiffyCards.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    using GiffyCards.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Orders = new HashSet<Order>();
            this.ShoppingCarts = new HashSet<ShoppingCart>();
            this.CustomerPhotos = new HashSet<CustomerPhoto>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

       

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public virtual ICollection<CustomerPhoto> CustomerPhotos { get; set; }
    }
}
