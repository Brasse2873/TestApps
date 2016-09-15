import org.junit.experimental.categories.Categories;
import org.junit.experimental.categories.Categories.ExcludeCategory;
import org.junit.experimental.categories.Categories.IncludeCategory;
import org.junit.runner.RunWith;
import org.junit.runners.Suite;

@RunWith(Categories.class)
@IncludeCategory({ProductBaseCategory.class})
@Suite.SuiteClasses({TestClassA.class})
@ExcludeCategory({BadTestCategory.class})
public class TestSuite {

}
