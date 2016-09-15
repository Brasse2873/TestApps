package se.titkb.multiparent;

import javafx.application.Application;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;


public class MultiParentApp extends Application {

	public static void main(String[] args) {
		launch(args);
	}

	@Override
	public void start(Stage stage) throws Exception {
		GridPane pane = new GridPane();
		pane.setGridLinesVisible(true);
		
		Scene scene = new Scene(pane);
		
		pane.add(getParent1(),0,0);
		pane.add(getParent2(), 1, 1);
		pane.add(getParent3(), 2, 2);
		
		stage.setScene(scene);
		stage.show();
		
	}

	private Parent getParent1() {
		Button btn = new Button("Parent1");
		btn.setMaxWidth(Double.MAX_VALUE);
		return btn;
	}

	private Node getParent2() {
		VBox node = new VBox();
		Button btn = new Button("Parent2");
		btn.setMaxWidth(Double.MAX_VALUE);
		node.getChildren().add(btn);
		return node;
	}
	
	private Node getParent3() {
		BorderPane pane = new BorderPane();
		Button topBtn = new Button("Parent3 Top");
		topBtn.setMaxWidth(Double.MAX_VALUE);
		pane.setTop(topBtn);
		pane.setRight(new Button("Parent3 Right"));
		pane.setBottom(new Button("Parent3 Bottom"));
		pane.setLeft(new Button("Parent3 Left"));
		pane.setCenter(new Button("Parent3 Center"));
		return pane;
	}
}
