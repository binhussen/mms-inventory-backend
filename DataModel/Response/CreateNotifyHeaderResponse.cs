using DataModel.Models.DTOs.Notify;

namespace DataModel.Response
{
    public class CreateNotifyHeaderResponse : BaseResponse<int>
    {
        public CreateNotifyHeaderResponse() : base()
        {

        }
        public NotifyHeaderForCreationDto NotifyHeader { get; set; }

    }
}
