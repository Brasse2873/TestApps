package se.titkb.stackpane;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

public class StackPaneApp extends Application{

	public static void main(String[] args) {
		launch(args);
	}

	@Override
	public void start(Stage primaryStage) throws Exception {
		StackPane pane = new StackPane();
		
		Button btn1 = new Button("First");
		btn1.setPrefSize(500, 500);		
		btn1.setStyle("-fx-base: #b6e7c9");
		pane.getChildren().add(btn1);
		
		Button btn2 = new Button("Second");
		btn2.setPrefSize(400, 400);		
		btn2.setStyle("-fx-base: #c6e7c9");
		pane.getChildren().add(btn2);

		Button btn3 = new Button("third");
		btn3.setPrefSize(300, 300);		
		btn3.setStyle("-fx-base: #d6e7c9");
		pane.getChildren().add(btn3);
		
		Scene scene = new Scene(pane);
		primaryStage.setScene(scene);
		primaryStage.show();
	}

}
