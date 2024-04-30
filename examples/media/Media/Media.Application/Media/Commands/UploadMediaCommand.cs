using MediatR;

namespace Media.Application.Media.Commands;

public record UploadMediaCommand(string fileName, Stream Stream) : IRequest<Guid>;