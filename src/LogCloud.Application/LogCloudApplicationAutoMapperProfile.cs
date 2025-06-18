using AutoMapper;
using LogCloud.Books;

namespace LogCloud;

public class LogCloudApplicationAutoMapperProfile : Profile
{
    public LogCloudApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
