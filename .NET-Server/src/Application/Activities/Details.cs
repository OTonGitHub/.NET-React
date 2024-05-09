namespace Application.Activities;
using Mediat
public class Details {
    public class Query: IRequest<Activity> {}

    public class Handler(DataContext ctx): IRequestHandler<Query, Activity> {

    }
}