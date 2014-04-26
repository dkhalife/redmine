package Core;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.SpringLayout;
import javax.swing.JLabel;
import java.awt.Font;
import javax.swing.JButton;

public class WorkTimer extends JFrame {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					WorkTimer frame = new WorkTimer();
					frame.setVisible(true);
				}
				catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public WorkTimer() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 370);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblWorkTimer = new JLabel("Work Timer");
		lblWorkTimer.setFont(new Font("Cambria Math", Font.BOLD, 22));
		lblWorkTimer.setBounds(154, 11, 125, 26);
		contentPane.add(lblWorkTimer);
		
		JLabel lblProject = new JLabel("Project:");
		lblProject.setFont(new Font("Tahoma", Font.BOLD, 16));
		lblProject.setBounds(10, 61, 74, 26);
		contentPane.add(lblProject);
		
		JButton btnChangeProject = new JButton("Change Project");
		btnChangeProject.setBounds(305, 65, 119, 23);
		contentPane.add(btnChangeProject);
		
		JLabel lblCurrentProject = new JLabel("");
		lblCurrentProject.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblCurrentProject.setBounds(94, 64, 185, 20);
		contentPane.add(lblCurrentProject);
		
		JLabel lblTask = new JLabel("Task:");
		lblTask.setFont(new Font("Tahoma", Font.BOLD, 16));
		lblTask.setBounds(10, 98, 45, 26);
		contentPane.add(lblTask);
		
		JLabel lblCurrentTime_ = new JLabel("Current Time:");
		lblCurrentTime_.setFont(new Font("Tahoma", Font.BOLD, 16));
		lblCurrentTime_.setBounds(10, 135, 125, 26);
		contentPane.add(lblCurrentTime_);
		
		JLabel lblTotalTime_ = new JLabel("Total Time:");
		lblTotalTime_.setFont(new Font("Tahoma", Font.BOLD, 16));
		lblTotalTime_.setBounds(10, 172, 95, 26);
		contentPane.add(lblTotalTime_);
		
		JLabel lblCurrentRate_ = new JLabel("Current Rate:");
		lblCurrentRate_.setFont(new Font("Tahoma", Font.BOLD, 16));
		lblCurrentRate_.setBounds(10, 209, 125, 26);
		contentPane.add(lblCurrentRate_);
		
		JLabel lblCurrentCharge_ = new JLabel("Current Charge:");
		lblCurrentCharge_.setFont(new Font("Tahoma", Font.BOLD, 16));
		lblCurrentCharge_.setBounds(10, 246, 147, 26);
		contentPane.add(lblCurrentCharge_);
		
		JLabel lblTotalCharge_ = new JLabel("Total Charge:");
		lblTotalCharge_.setFont(new Font("Tahoma", Font.BOLD, 16));
		lblTotalCharge_.setBounds(10, 283, 147, 26);
		contentPane.add(lblTotalCharge_);
		
		JButton btnChangeTask = new JButton("Change Task");
		btnChangeTask.setBounds(305, 99, 119, 23);
		contentPane.add(btnChangeTask);
		
		JLabel lblCurrentTask = new JLabel("");
		lblCurrentTask.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblCurrentTask.setBounds(65, 102, 185, 20);
		contentPane.add(lblCurrentTask);
		
		JLabel lblCurrentTime = new JLabel("");
		lblCurrentTime.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblCurrentTime.setBounds(131, 135, 148, 20);
		contentPane.add(lblCurrentTime);
		
		JLabel lblTotalTime = new JLabel("");
		lblTotalTime.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblTotalTime.setBounds(115, 172, 164, 20);
		contentPane.add(lblTotalTime);
		
		JLabel lblCurrentRate = new JLabel("");
		lblCurrentRate.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblCurrentRate.setBounds(125, 209, 164, 20);
		contentPane.add(lblCurrentRate);
		
		JLabel lblCurrentCharge = new JLabel("");
		lblCurrentCharge.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblCurrentCharge.setBounds(154, 246, 164, 20);
		contentPane.add(lblCurrentCharge);
		
		JLabel lblTotalCharge = new JLabel("");
		lblTotalCharge.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblTotalCharge.setBounds(131, 283, 164, 20);
		contentPane.add(lblTotalCharge);
		
		JButton btnNewButton = new JButton("");
		btnNewButton.setBounds(305, 135, 33, 23);
		contentPane.add(btnNewButton);
		
		JButton button = new JButton("");
		button.setBounds(348, 135, 33, 23);
		contentPane.add(button);
		
		JButton button_1 = new JButton("");
		button_1.setBounds(391, 135, 33, 23);
		contentPane.add(button_1);
		
		JButton btnReset = new JButton("Reset");
		btnReset.setBounds(305, 169, 119, 23);
		contentPane.add(btnReset);
		
		JButton btnChangeRate = new JButton("Change Rate");
		btnChangeRate.setBounds(305, 206, 119, 23);
		contentPane.add(btnChangeRate);
	}
}
