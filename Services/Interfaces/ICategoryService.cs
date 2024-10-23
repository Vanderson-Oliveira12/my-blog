﻿using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Repositories;
using MyBlog.DTOs;

namespace MyBlog.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse<IEnumerable<ResponseCategoryDTO>>> GetCategoriesAsync();   
        Task<ApiResponse<ResponseCategoryDTO>> GetCategoryByIdAsync(Guid id);
        Task<ApiResponse<RequestCategoryDTO>> CreateCategoryAsync(RequestCategoryDTO requestCategoryDTO);
        Task<ApiResponse<ResponseCategoryDTO>> UpdateCategoryAsync(Guid id, RequestCategoryDTO requestCategoryDTO);
        Task<ApiResponse<bool>> DeleteCategoryAsync(Guid id);
    }
}
