using Abp.AutoMapper;
using AbpCore.Models;
using System.ComponentModel.DataAnnotations;

namespace AbpCore.Tasks.Dtos
{
    /*=====================================

    创建人：吕福安

    创建时间：

    =====================================*/
    [AutoMapTo(typeof(Task))] //定义单向映射
    public class CreateTaskInput
    {
        public int? AssignedPersonId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        public TaskState State { get; set; }
        public override string ToString()
        {
            return string.Format("[CreateTaskInput > AssignedPersonId = {0}, Description = {1}]", AssignedPersonId, Description);
        }
    }
}
