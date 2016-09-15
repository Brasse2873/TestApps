package se.titkb.gridpane;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;

public class GridPaneApp extends Application{

	public static void main(String[] args) {
		launch(args);

	}

	@Override
	public void start(Stage primaryStage) throws Exception {
		GridPane pane = new GridPane();
		pane.setPadding(new Insets(20));
		pane.setVgap(3);
		pane.setHgap(3);
		pane.add(new Button("0,0"), 0, 0);
		pane.add(new Button("1,0"), 1, 0);
		pane.add(new Button("0,1"), 0, 1);
		pane.add(new Button("1,1"), 1, 1);
		pane.add(new Button("0-1,2-3"), 0, 2,2,2);

		Scene scene = new Scene(pane);
		
		primaryStage.setScene(scene);
		primaryStage.show();
	}

}
