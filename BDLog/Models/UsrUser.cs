using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("USR_USER")]
    [Index(nameof(Normalizedemail), Name = "EmailIndex")]
    [Index(nameof(Normalizedusername), Name = "UserNameIndex", IsUnique = true)]
    public partial class UsrUser
    {
        public UsrUser()
        {
            BdpfBdpfmaBdCreatedbyNavigations = new HashSet<BdpfBdpfma>();
            BdpfBdpfmaBdModifiedbyNavigations = new HashSet<BdpfBdpfma>();
            BdpfBlogs = new HashSet<BdpfBlog>();
            UsrUserclaims = new HashSet<UsrUserclaim>();
            UsrUserlogins = new HashSet<UsrUserlogin>();
            UsrUserroles = new HashSet<UsrUserrole>();
            UsrUsertokens = new HashSet<UsrUsertoken>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("FULLUSER")]
        public string Fulluser { get; set; }
        [Column("USERNAME")]
        [StringLength(256)]
        public string Username { get; set; }
        [Column("NORMALIZEDUSERNAME")]
        [StringLength(256)]
        public string Normalizedusername { get; set; }
        [Column("EMAIL")]
        [StringLength(256)]
        public string Email { get; set; }
        [Column("NORMALIZEDEMAIL")]
        [StringLength(256)]
        public string Normalizedemail { get; set; }
        [Column("EMAILCONFIRMED")]
        public bool Emailconfirmed { get; set; }
        [Column("PASSWORDHASH")]
        public string Passwordhash { get; set; }
        [Column("SECURITYSTAMP")]
        public string Securitystamp { get; set; }
        [Column("CONCURRENCYSTAMP")]
        public string Concurrencystamp { get; set; }
        [Column("PHONENUMBER")]
        public string Phonenumber { get; set; }
        [Column("PHONENUMBERCONFIRMED")]
        public bool Phonenumberconfirmed { get; set; }
        [Column("TWOFACTORENABLED")]
        public bool Twofactorenabled { get; set; }
        [Column("LOCKOUTEND")]
        public DateTimeOffset? Lockoutend { get; set; }
        [Column("LOCKOUTENABLED")]
        public bool Lockoutenabled { get; set; }
        [Column("ACCESSFAILEDCOUNT")]
        public int Accessfailedcount { get; set; }

        [InverseProperty(nameof(BdpfBdpfma.BdCreatedbyNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmaBdCreatedbyNavigations { get; set; }
        [InverseProperty(nameof(BdpfBdpfma.BdModifiedbyNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmaBdModifiedbyNavigations { get; set; }
        [InverseProperty(nameof(BdpfBlog.BlogAuthorNavigation))]
        public virtual ICollection<BdpfBlog> BdpfBlogs { get; set; }
        [InverseProperty(nameof(UsrUserclaim.User))]
        public virtual ICollection<UsrUserclaim> UsrUserclaims { get; set; }
        [InverseProperty(nameof(UsrUserlogin.User))]
        public virtual ICollection<UsrUserlogin> UsrUserlogins { get; set; }
        [InverseProperty(nameof(UsrUserrole.User))]
        public virtual ICollection<UsrUserrole> UsrUserroles { get; set; }
        [InverseProperty(nameof(UsrUsertoken.User))]
        public virtual ICollection<UsrUsertoken> UsrUsertokens { get; set; }
    }
}
