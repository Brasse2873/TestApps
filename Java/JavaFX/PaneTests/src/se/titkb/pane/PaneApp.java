package se.titkb.pane;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

public class PaneApp extends Application{

	public static void main(String[] args) {
		launch(args);
	}

	@Override
	public void start(Stage primaryStage) throws Exception {
		Pane pane = new Pane();
		
		Scene scene = new Scene(pane);
		primaryStage.setScene(scene);
		primaryStage.show();		
	}

}
