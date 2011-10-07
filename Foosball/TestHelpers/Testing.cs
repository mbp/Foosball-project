using Moq;
using StructureMap;
using StructureMap.AutoMocking;

namespace Mvno.TestHelpers
{
	public abstract class Testing<TClassUnderTest>
		where TClassUnderTest : class
	{
		protected MoqAutoMocker<TClassUnderTest> MoqAutoMocker
		{
			get;
			private set;
		}

		protected TClassUnderTest ClassUnderTest
		{
			get
			{
				return MoqAutoMocker.ClassUnderTest;
			}
		}

		public Testing()
		{
			MoqAutoMocker = new MoqAutoMocker<TClassUnderTest>();
		}

		protected IContainer Container
		{
			get
			{
				return MoqAutoMocker.Container;
			}
		}

		protected Mock<T> Get<T>()
			where T : class
		{
			return Mock.Get(MoqAutoMocker.Get<T>());
		}
	}
}