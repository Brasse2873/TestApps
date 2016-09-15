import static org.junit.Assert.*;

import org.junit.Test;
import org.junit.experimental.categories.Category;


@Category(GoodTestsCategory.class)
public class TestClassB {

	@Test
	public void test1() {
		System.out.println("TestClassB:test1");
	}
	
	@Test
	public void test2() {
		System.out.println("TestClassB:test2");
	}
}
