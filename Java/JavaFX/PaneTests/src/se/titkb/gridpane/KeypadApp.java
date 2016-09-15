package se.titkb.gridpane;

import javafx.application.Application;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;

public class KeypadApp extends Application{

	public static void main(String[] args) {
		launch(args);

	}

	@Override
	public void start(Stage stage) throws Exception {
		GridPane pane = new GridPane();
		pane.add(new Button("7"), 0, 0);
		pane.add(new Button("8"), 1, 0);
		pane.add(new Button("9"), 2, 0);
		pane.add(new Button("4"), 0, 1);
		pane.add(new Button("5"), 1, 1);
		pane.add(new Button("6"), 2, 1);
		pane.add(new Button("1"), 0, 2);
		pane.add(new Button("2"), 1, 2);
		pane.add(new Button("3"), 2, 2);
		pane.add(new Button("0"), 0, 3);
		pane.add(new Button("00"), 1, 3, 2,1);
		
		for( Node node : pane.getChildren())
			((Button)node).setMaxWidth(Double.MAX_VALUE);
		
		Scene scene = new Scene(pane);
		stage.setScene(scene);
		stage.show();
	}

}
