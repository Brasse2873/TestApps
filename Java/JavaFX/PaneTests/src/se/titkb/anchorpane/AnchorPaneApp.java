package se.titkb.anchorpane;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

public class AnchorPaneApp extends Application {

	public static void main(String[] args) {
		launch(args);

	}

	@Override
	public void start(Stage primaryStage) throws Exception {
		AnchorPane pane = new AnchorPane();
		
		pane.prefHeight(500);
		pane.prefWidth(500);
		

		Button btn1 = new Button("First");
		Button btn2 = new Button("Second");
		Button btn3 = new Button("Third");
		Button btn4 = new Button("Fourth");

		pane.getChildren().addAll(btn1,btn2,btn3,btn4);
		
		pane.setTopAnchor(btn1, 10.0);
		pane.setRightAnchor(btn2, 10.0);
		pane.setBottomAnchor(btn3, 10.0);
		pane.setLeftAnchor(btn4, 10.0);

		
		Scene scene = new Scene(pane);
		primaryStage.setScene(scene);
		primaryStage.show();
	}

}
