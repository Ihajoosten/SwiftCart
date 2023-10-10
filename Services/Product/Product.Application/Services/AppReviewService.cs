using AutoMapper;
using Product.Application.Dto.Review;
using Product.Application.Interfaces;
using Product.Application.Services.Base;
using Product.Core.Entities;
using Product.Core.IRepositories;

namespace Product.Application.Services
{
    public class AppReviewService : ApplicationService<Review, ReviewDto, CreateReviewDto, UpdateReviewDto>, IAppReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public AppReviewService(IReviewRepository reviewRepository, IMapper mapper)
            : base(reviewRepository, mapper)
        {
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
        }

        public async Task<double> GetAverageRatingByProductIdAsync(int productId)
        {
            return await _reviewRepository.GetAverageRatingByProductIdAsync(productId);
        }

        public async Task<IEnumerable<ReviewDto?>?> GetReviewsByProductIdAsync(int productId)
        {
            var reviews = await _reviewRepository.GetReviewsByProductIdAsync(productId);
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public override async Task<ReviewDto> CreateAsync(CreateReviewDto createDto)
        {
            createDto.CreatedAt = createDto.CreatedAt == default ? DateTime.UtcNow : createDto.CreatedAt;

            var entity = _mapper.Map<Review>(createDto);
            entity = await _reviewRepository.AddAsync(entity);

            return _mapper.Map<ReviewDto>(entity);
        }

        public override async Task<bool> UpdateAsync(int id, UpdateReviewDto updateDto)
        {
            updateDto.UpdatedAt = updateDto.UpdatedAt == default ? DateTime.UtcNow : updateDto.UpdatedAt;

            var entity = await _reviewRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(updateDto, entity);

            return await _reviewRepository.UpdateAsync(entity);
        }
    }
}
