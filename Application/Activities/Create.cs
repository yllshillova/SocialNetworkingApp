using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
                
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                // nuk jem tu interact me database deri qitash veq jem tu e bo track se jem tu e shtu ni activity ne memory
                _context.Activities.Add(request.Activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}