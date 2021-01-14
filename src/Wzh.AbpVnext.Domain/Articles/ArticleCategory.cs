using EasyAbp.Abp.Trees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Wzh.AbpVnext.Articles
{
 
    public class ArticleCategory : AuditedAggregateRoot<Guid>, ITree<ArticleCategory>
    {
        public ArticleCategory(Guid id)
            : base(id)
        {
            Children = new List<ArticleCategory>();
        }
        /// <summary>
        /// ����
        /// </summary>
        [StringLength(100)]
        public virtual string DisplayName { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        [StringLength(100)]
        public virtual string Code { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual int Level { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual ArticleCategory Parent { get; set; }
        /// <summary>
        /// ����Id
        /// </summary>
        public virtual Guid? ParentId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Display(Name = "����")]
        public int DisplayOrder { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual ICollection<ArticleCategory> Children { get; set; }

        protected ArticleCategory()
        {
        }

        public ArticleCategory(
            Guid id,
            string displayName,
            string code,
            int level,
            ArticleCategory parent,
            Guid? parentId,
            ICollection<ArticleCategory> children
        ) : base(id)
        {
            DisplayName = displayName;
            Code = code;
            Level = level;
            Parent = parent;
            ParentId = parentId;
            Children = children;
        }
    }
}
