using System;
namespace LiJiT.Domain.DTO
{
    public static class ResponseExtension
    {
        public static T ToSuccess<T>(this T input) where T : BaseResponse
        {
            input.MessageCode = (int)ResponseCodes.Success;
            input.Message = ResponseCodes.Success.ToString();
            input.HasError = false;
            return input;
        }
        public static T ToInternalError<T>(this T input) where T : BaseResponse
        {
            input.MessageCode = (int)ResponseCodes.InternalError;
            input.Message = ResponseCodes.InternalError.ToString();
            input.HasError = true;
            return input;
        }
        public static T ToInvalidInput<T>(this T input) where T : BaseResponse
        {
            input.MessageCode = (int)ResponseCodes.InvalidInput;
            input.Message = ResponseCodes.InvalidInput.ToString();
            input.HasError = true;
            return input;
        }
        public static T ToNotFound<T>(this T input) where T : BaseResponse
        {
            input.MessageCode = (int)ResponseCodes.NotFound;
            input.Message = ResponseCodes.NotFound.ToString();
            input.HasError = true;
            return input;
        }
    }
}
