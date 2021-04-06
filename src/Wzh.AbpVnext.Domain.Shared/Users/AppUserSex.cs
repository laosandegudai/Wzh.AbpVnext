using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wzh.AbpVnext.Users
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum AppUserSex
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Display(Name = "未知")]
        Unknown,
        /// <summary>
        /// 男
        /// </summary>
        [Display(Name = "男")]
        Man,
        /// <summary>
        /// 女
        /// </summary>
        [Display(Name = "女")]
        Woman,

    }
}
