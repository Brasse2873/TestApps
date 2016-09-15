import static org.junit.Assert.*;

import org.junit.Test;
import org.junit.experimental.categories.Category;

@Category(ProductBaseCategory.class)
public class TestClassA {

	@Test
	@Category(GoodTestCategory.class)
	public void GoodTest() {
		System.out.println("TestClassA:GoodTest");
	}

	@Test
	@Category(BadTestCategory.class)
	public void BadTest() {
		System.out.println("TestClassA:BadTest");
	}
	
	@Test
	public void GenericTest(){
		System.out.println("TestClassA:GenericTest");
	}
	
	@Test
	@Category({GoodTestCategory.class,BadTestCategory.class})
	public void GoodAndBadTest(){
		System.out.println("TestClassA:GoodAndBadTest");
	}
}
