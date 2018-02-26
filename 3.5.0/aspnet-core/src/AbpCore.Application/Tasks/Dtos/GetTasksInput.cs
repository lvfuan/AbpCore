using AbpCore.Models;

namespace AbpCore.Tasks.Dtos
{
    /*=====================================

    创建人：吕福安

    创建时间：

    =====================================*/
    public class GetTasksInput
    {
        public TaskState? State { get; set; }

        public int? AssignedPersonId { get; set; }
    }
}
