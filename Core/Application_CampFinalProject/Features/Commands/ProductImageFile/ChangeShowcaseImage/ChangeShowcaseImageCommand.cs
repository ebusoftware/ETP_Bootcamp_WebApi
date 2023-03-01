using Application_CampFinalProject.Dtos.ProductImageFile;
using Application_CampFinalProject.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands
{
    public class ChangeShowcaseImageCommand:IRequest<ShowCaseImageDTO>
    {     
        public int ImageId { get; set; }
        public int ProductId { get; set; }

        public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommand, ShowCaseImageDTO>
        {
            private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

            public ChangeShowcaseImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository)
            {
                _productImageFileWriteRepository = productImageFileWriteRepository;
            }

            public async Task<ShowCaseImageDTO> Handle(ChangeShowcaseImageCommand request, CancellationToken cancellationToken)
            {
                var query = _productImageFileWriteRepository.Table
                      .Include(p => p.Products)
                      .SelectMany(p => p.Products, (pif, p) => new
                      {
                          pif,
                          p
                      });

                var data = await query.FirstOrDefaultAsync(p => p.p.Id == request.ProductId && p.pif.Showcase);

                if (data != null)
                    data.pif.Showcase = false;

                var image = await query.FirstOrDefaultAsync(p => p.pif.Id == request.ImageId);
                if (image != null)
                    image.pif.Showcase = true;

                await _productImageFileWriteRepository.SaveAsync();

                return new();
            }
        }
    }
}
