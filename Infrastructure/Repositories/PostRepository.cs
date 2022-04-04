using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{

    public class PostRepository : IPostRepository
    {
        private static readonly ISet<Post> _posts = new HashSet<Post>()
        {
            new Post(1,"Jak zostac programistą","Tresc 1"),
            new Post(2,"Ile zarabia programista","Tresc 2"),
            new Post(3,"Dlaczego warto zostac programistą","Tresc 3")
        };

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }
        public Post GetById(int id)
        {
            return _posts.FirstOrDefault(x => x.Id == id);

        }
        public Post Add(Post post)
        {
            post.Id = _posts.Count() + 1;
            post.Created = DateTime.UtcNow;
            _posts.Add(post);
            return post;
        }
        public void Update(Post post)
        {
            post.LastModified = DateTime.UtcNow;
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
        }
        public IEnumerable<Post> GetByTitle(string title)
        {
            var posts = _posts.Where(x => x.Title.ToUpper().Contains(title.ToUpper())).ToHashSet();
            return posts;
        }


    }
}
