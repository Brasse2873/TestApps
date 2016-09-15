package se.titkb.hellocssbutton;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Stage;

public class HelloCssButton extends Application{

	public static void main(String[] args) {
		launch(args);
	}

	
	@Override
	public void start(Stage stage) throws Exception {
		Button btn = new Button("First");
		btn.getStyleClass().add("my-button");
		
		Scene scene = new Scene(btn);
		scene.getStylesheets().add("se/titkb/hellocssbutton/hellocssbutton.css");
		
		stage.setScene(scene);
		stage.show();
		
	}

}
