#include<iostream>
#include<ctime>
#include<stdlib.h>
#include<conio.h>
using namespace std;
int w(int p[4][4])
{
	int flagw=0;
	for(int i=0;i<4;i++)
	    for(int j=3;j>0;j--)
	    {
	    	if(p[j][i]!=0)
	    	{
	    		if(p[j-1][i]==0 || p[j-1][i]==p[j][i])
	    		{
	    		    flagw=1;
	    		    return flagw;
	    	    }
			}
		}
	return flagw;
}
int s(int p[4][4])
{
	int flags=0;
	for(int i=0;i<4;i++)
	    for(int j=0;j<3;j++)
	    {
	    	if(p[j][i]!=0)
	    	{
	    		if(p[j+1][i]==0 || p[j+1][i]==p[j][i])
	    		{
				    flags=1;
	    		    return flags;
	    		}
			}
		}
	return flags;
}
int a(int p[4][4])
{
	int flaga=0;
	for(int i=0;i<4;i++)
	    for(int j=3;j>0;j--)
	    {
	    	if(p[i][j]!=0)
	    	{
				    if(p[i][j-1]==0 || p[i][j-1]==p[i][j])
	    		    {
				        flaga=1;
	    		        return flaga;
	    	    	}
			}
		}
	return flaga;
}
int d(int p[4][4])
{
	int flagd=0;
	for(int i=0;i<4;i++)
	    for(int j=0;j<3;j++)
	    {
	    	if(p[i][j]!=0)
	    	{
	    		if(p[i][j+1]==0 || p[i][j+1]==p[i][j])
	    		{
				    flagd=1;
	    		    return flagd;
	    		}
			}
		}
	return flagd;
}
void wop(int t[4][4],int &score)
{
	for(int i=0;i<4;i++)
	{
		for(int j=0;j<3;j++)
		{
			if(t[j][i]!=0)
			{
				for(int k=j+1;k<4;k++)
				{
					if(t[k][i]==t[j][i])
					{
					    t[j][i]+=t[k][i];
					    t[k][i]=0;
					    score+=t[j][i];
					    break;
			    	}
			    	else if(t[k][i]!=0)
			    	break;
				}
			}
		}
		for(int p=0;p<3;p++)
		{
			if(t[p][i]==0)
			{
				for(int l=p+1;l<4;l++)
				if(t[l][i]!=0)
				{
					t[p][i]=t[l][i];
					t[l][i]=0;
					break;
				}
			}
		}
	}
}
void sop(int t[4][4], int &score)
{
	for(int i=0;i<4;i++)
	{
		for(int j=3;j>0;j--)
		{
			if(t[j][i]!=0)
			{
				for(int k=j-1;k>=0;k--)
				{
					if(t[k][i]==t[j][i])
					{
					    t[j][i]+=t[k][i];
					    t[k][i]=0;
					    score+=t[j][i];
					    break;
			    	}
			    	else if(t[k][i]!=0)
			    	break;
				}
			}
		}
		for(int p=3;p>0;p--)
		{
			if(t[p][i]==0)
			{
				for(int l=p-1;l>=0;l--)
				if(t[l][i]!=0)
				{
					t[p][i]=t[l][i];
					t[l][i]=0;
					break;
				}
			}
		}
	}
}
void aop(int t[4][4],int &score)
{
	for(int i=0;i<4;i++)
	{
		for(int j=0;j<3;j++)
		{
			if(t[i][j]!=0)
			{
				for(int k=j+1;k<4;k++)
				{
					if(t[i][k]==t[i][j])
					{
					    t[i][j]+=t[i][k];
					    t[i][k]=0;
					    score+=t[i][j];
					    break;
			    	}
			    	else if(t[i][k]!=0)
			    	    break;
				}
			}
		}
		for(int p=0;p<3;p++)
		{
			if(t[i][p]==0)
			{
				for(int l=p+1;l<4;l++)
				if(t[i][l]!=0)
				{
					t[i][p]=t[i][l];
					t[i][l]=0;
					break;
				}
			}
		}
	}
}
void dop(int t[4][4],int &score)
{
	for(int i=0;i<4;i++)
	{
		for(int j=3;j>0;j--)
		{
			if(t[i][j]!=0)
			{
				for(int k=j-1;k>=0;k--)
				{
					if(t[i][k]==t[i][j])
					{
					    t[i][j]+=t[i][k];
					    t[i][k]=0;
					    score+=t[i][j];
					    break;
			    	}
			    	else if(t[i][k]!=0)
			    	break;
				}
			}
		}
		for(int p=3;p>0;p--)
		{
			if(t[i][p]==0)
			{
				for(int l=p-1;l>=0;l--)
				if(t[i][l]!=0)
				{
					t[i][p]=t[i][l];
					t[i][l]=0;
					break;
				}
			}
		}
	}
}
int main()
{
	int table[4][4]={0};
	int flag=1,flag1=1,sum=1,score=0,m=0;
	int x,y,ti;
	char op;
	while(flag)
	{ 
	    srand(time(NULL));	
		while(1)
		{
			x=0;
			y=0;
			ti=0;
			x=rand()%4;
			y=rand()%4;
			ti=rand()%2;
			if(table[x][y]==0)
			{
			    table[x][y]=ti*2+2;
				break;
			}
		}
		for(int k=0;k<4;k++)
		{
			for(int l=0;l<4;l++)
				cout<<table[k][l]<<'\t';
			cout<<endl;
		}
		sum=w(table)+s(table)+a(table)+d(table); 
		cout<<w(table)<<s(table)<<a(table)<<d(table);
		if(sum==0)
		{
			cout<<"游戏结束"<<endl
			    <<"总分数为："<<score<<endl;
			break; 
		}
		while(op=getch())
		{
			if((op=='w' && w(table)==0) || (op=='s' && s(table)==0) || (op=='a' && a(table)==0) || (op=='d' && d(table)==0) || (op!='w' && op!='s' && op!='a' && op!='d'))
			continue;
			else
			{
				switch(op)
				{
					case 'w':wop(table,score); break;
					case 's':sop(table,score); break;
					case 'a':aop(table,score); break;
					case 'd':dop(table,score); break;
				}
				break;
			}
		}
		system("cls");
		cout<<"当前分数："<<score<<endl;
		sum=0; 
	}
	return 0;
}






























