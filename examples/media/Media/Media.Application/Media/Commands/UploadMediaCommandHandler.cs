using MediatR;

namespace Media.Application.Media.Commands;

public class UploadMediaCommandHandler : IRequestHandler<UploadMediaCommand, Guid>
{
    public Task<Guid> Handle(UploadMediaCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}