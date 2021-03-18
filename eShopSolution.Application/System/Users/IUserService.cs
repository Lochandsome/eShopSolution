using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
        // cái dưới nghĩa là chúng ta lấy đc 1 danh sách user và trả về 1 model phân trang
        Task<PagedResult<UserVm>> GetUsersPaging(GetUserPagingRequest request);
    }
}
