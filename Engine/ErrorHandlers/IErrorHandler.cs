using System;

namespace Engine.ErrorHandlers
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
