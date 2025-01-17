﻿using API.Data;
using API.Entities;
using API.Interfaces;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class BlogRepository : IBlogRepository, IDisposable
    {
        private ApplicationDbContext _context;

        public BlogRepository(ApplicationDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Blog>> GetAllBlogAsync()
        {
            return await _context.Blogs.ToListAsync();
        }
        public async Task<Blog> GetBlogAsync(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }
        public async Task CreateBlogAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
        }
        public void UpdateBlog(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;
        }
        public void DeleteBlog(Blog blog)
        {
            _context.Blogs.Remove(blog);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

    }
}
