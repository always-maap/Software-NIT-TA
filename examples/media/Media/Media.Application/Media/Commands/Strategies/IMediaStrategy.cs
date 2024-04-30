namespace Media.Application.Media.Commands.Strategies;

public interface IMediaStrategy
{
    Task<Guid> Handle(UploadMediaCommand command, CancellationToken cancellationToken);
}