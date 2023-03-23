using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDELog.Models
{
    [Table("BDPF_BLOG")]
    public partial class BdpfBlog
    {
        [Key]
        [Column("BLOG_ID")]
        public int BlogId { get; set; }
        [Required]
        [Column("BLOG_TITLE")]
        [StringLength(100)]
        public string BlogTitle { get; set; }
        [Required]
        [Column("BLOG_TXT")]
        [StringLength(1000)]
        public string BlogTxt { get; set; }
        [Column("BLOG_DATE", TypeName = "DATE")]
        public DateTime? BlogDate { get; set; }
        [Column("BLOG_AUTHOR")]
        public int? BlogAuthor { get; set; }

        [ForeignKey(nameof(BlogAuthor))]
        [InverseProperty(nameof(UsrUser.BdpfBlogs))]
        public virtual UsrUser BlogAuthorNavigation { get; set; }
    }
}
