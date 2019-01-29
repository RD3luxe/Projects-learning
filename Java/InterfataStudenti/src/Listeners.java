import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;

public class Listeners implements ActionListener 
{
	int numClicks =0;
	@Override
	public void actionPerformed(ActionEvent e)
	{
		JButton butonApasat = (JButton)e.getSource();
		if(butonApasat.getActionCommand().equals("contor")) {
			numClicks++;
			butonApasat.setText("Apasat: " + numClicks);
			Student st = new Student();
			st.set_answer("Test");
			st.writeToFile();
			}
	}
}
