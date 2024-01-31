using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class PictureService : IServiceOfAll<PictureDTO>
    {
        IUnitOfWork Database { get; set; }

        public PictureService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(PictureDTO pictureDTO)
        {
            var picure = new Picture
            {
                Id = pictureDTO.Id,
                PictureName = pictureDTO.PictureName,
                PictureUrl = pictureDTO.PictureUrl,
                RentalApartmentId = pictureDTO.RentalApartmentId
            };
            await Database.Picture.Create(picure);
            await Database.Save();
        }

        public async Task Update(PictureDTO pictureDTO)
        {
            var picure = new Picture
            {
                Id = pictureDTO.Id,
                PictureName = pictureDTO.PictureName,
                PictureUrl = pictureDTO.PictureUrl,
                RentalApartmentId = pictureDTO.RentalApartmentId
            };
            await Database.Picture.Update(picure);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.Picture.Delete(id);
            await Database.Save();
        }

        public async Task<PictureDTO> Get(int id)
        {
            var picture = await Database.Picture.Get(id);
            if (picture == null)
                throw new ValidationException("Wrong picture!", "");
            return new PictureDTO
            {
                Id = picture.Id,
                PictureName = picture.PictureName,
                PictureUrl = picture.PictureUrl,
                RentalApartmentId = picture.RentalApartmentId
        };
        }

        public async Task<IEnumerable<PictureDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Picture, PictureDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Picture>, IEnumerable<PictureDTO>>(await Database.Picture.GetAll());
        }

    }
}
