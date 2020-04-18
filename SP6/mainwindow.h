#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QTime>
#include <QTimer>
#include <QLabel>


QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);    
    ~MainWindow();

private slots:
    void on_actionStart_triggered();
    void slotTimerAlarm();
    void on_actionStop_triggered();

private:
    Ui::MainWindow *ui;
    QTimer *timer;
    QLabel *label = new QLabel("SOME TEXT", this);
    bool first = true;
    bool move = false;
    bool right = true;
    int x;
    int y;
};
#endif // MAINWINDOW_H
