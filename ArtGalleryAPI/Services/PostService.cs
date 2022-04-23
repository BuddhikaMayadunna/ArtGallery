using ArtGalleryAPI.Entities;
using ArtGalleryAPI.Models;
using FlockAPI.Data.UnitOfWork;

namespace ArtGalleryAPI.Services
{
    public class PostService :IPostService
    {
        private readonly IUnitOfWorkAsync unitOfWork;

        public PostService(IUnitOfWorkAsync unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> DeleteAsync(PostModel model)
        {
            var post = await unitOfWork.GetRepositoryAsync<Post>().GetOneAsync(c => c.PostId == model.PostId);
            unitOfWork.GetRepositoryAsync<Post>().Delete(post);
            return await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PostModel>> GetAsync()
        {
            var PostModelList = new List<PostModel>();
            var postList = await unitOfWork.GetRepositoryAsync<Post>().GetAllAsync();

            foreach (var post in postList)
            {
                PostModelList.Add(new PostModel { PostId = post.PostId, Content = post.Content, Date = post.Date, UserId = post.UserId });
            }
            return PostModelList;
        }

        public async Task<int> InsertAsync(PostModel model)
        {
            var post = new Post
            {
                //PostId = model.PostId,
                UserId = model.UserId,
                Content = model.Content,
                Date = DateTime.UtcNow,
            };

            unitOfWork.GetRepositoryAsync<Post>().Insert(post);

            var vowelCount = GetVowelCount(model.Content);
            var wordCount = GetTotalWordCount(model.Content);
            var vowelStat = new StatVowels
            {
                PostId = post.PostId,
                SingleVowelCount = vowelCount,
                TotalWordCount = wordCount,
                Date = DateTime.UtcNow,
                PairVowelCount = 0
            };
            unitOfWork.GetRepositoryAsync<StatVowels>().Insert(vowelStat);

            return await unitOfWork.SaveAsync();

        }
        public async Task<PostModel> UpdateAsync(PostModel model)
        {
            var post = await unitOfWork.GetRepositoryAsync<Post>().GetOneAsync(c => c.PostId == model.PostId);
            post.Content = model.Content;
            return new PostModel();
        }

        private int GetVowelCount(string content)
        {
            return content.Count("AEIOUaeiou".Contains);
        }

        private int GetTotalWordCount(string content)
        {
            return content.Trim().Split(' ').Count();
        }
    }
}
