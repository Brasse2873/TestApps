
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.text.Font;
import javafx.stage.Stage;



public class HelloWorldApp extends Application {

	public static void main(String[] args) {
		launch(args);

	}

	@Override
	public void start(Stage primaryStage) throws Exception {

		Label lbl = new Label("Hello World!");
		lbl.setFont(new Font(100));
		Scene scene = new Scene(lbl);
		primaryStage.setScene(scene);
	    primaryStage.show();  
	}

}
