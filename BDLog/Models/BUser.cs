using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("B_USER")]
    [Index(nameof(Normalizedemail), Name = "EmailIndex")]
    [Index(nameof(Normalizedusername), Name = "UserNameIndex", IsUnique = true)]
    public partial class BUser
    {
        public BUser()
        {
            BUserclaims = new HashSet<BUserclaim>();
            BUserlogins = new HashSet<BUserlogin>();
            BUserroles = new HashSet<BUserrole>();
            BUsertokens = new HashSet<BUsertoken>();
            BdpfBdpfmaBdCreatedbyNavigations = new HashSet<BdpfBdpfma>();
            BdpfBdpfmaBdModifiedbyNavigations = new HashSet<BdpfBdpfma>();
            BdpfBlogs = new HashSet<BdpfBlog>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("FULLUSER")]
        public string Fulluser { get; set; }
        [Column("DEFCELL")]
        public int Defcell { get; set; }
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

        [InverseProperty(nameof(BUserclaim.User))]
        public virtual ICollection<BUserclaim> BUserclaims { get; set; }
        [InverseProperty(nameof(BUserlogin.User))]
        public virtual ICollection<BUserlogin> BUserlogins { get; set; }
        [InverseProperty(nameof(BUserrole.User))]
        public virtual ICollection<BUserrole> BUserroles { get; set; }
        [InverseProperty(nameof(BUsertoken.User))]
        public virtual ICollection<BUsertoken> BUsertokens { get; set; }
        [InverseProperty(nameof(BdpfBdpfma.BdCreatedbyNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmaBdCreatedbyNavigations { get; set; }
        [InverseProperty(nameof(BdpfBdpfma.BdModifiedbyNavigation))]
        public virtual ICollection<BdpfBdpfma> BdpfBdpfmaBdModifiedbyNavigations { get; set; }
        [InverseProperty(nameof(BdpfBlog.BlogAuthorNavigation))]
        public virtual ICollection<BdpfBlog> BdpfBlogs { get; set; }
    }
}
