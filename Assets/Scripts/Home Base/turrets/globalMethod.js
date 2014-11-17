#pragma strict

function Start () {

}

function Update () {

}

function ChangeTurret(turret, level, type) 
{	
	switch(turret)
	{
		case 1:
			change1(level, type);
		break;
		case 2:
		
		break;
		case 3:
		
		break;
		case 4:
		
		break; 
		case 5:
		
		break; 
		default:
		
		break;
	}
}

//change turret 1
function change1(level, type)
{
	//changes level of turret
	Turret1Control.level1 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret1Control.type1 = 1;
	}
	else if(type == "BOMB")
	{
		Turret1Control.type1 = 3;
	}
	else
	{
		Turret1Control.type1 = 2;
	}
}

//change turret 2
function change2(level, type)
{
	//changes level of turret
	Turret2Control.level2 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret2Control.type2 = 1;
	}
	else if(type == "BOMB")
	{
		Turret2Control.type2 = 3;
	}
	else
	{
		Turret2Control.type2 = 2;
	}
}

//change turret 3
function change3(level, type)
{
	//changes level of turret
	Turret3Control.level3 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret3Control.type3 = 1;
	}
	else if(type == "BOMB")
	{
		Turret3Control.type3 = 3;
	}
	else
	{
		Turret3Control.type3 = 2;
	}
}

//change turret 4
function change4(level, type)
{
	//changes level of turret
	Turret4Control.level4 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret4Control.type4 = 1;
	}
	else if(type == "BOMB")
	{
		Turret4Control.type4 = 3;
	}
	else
	{
		Turret4Control.type4 = 2;
	}
}

//change turret 5
function change5(level, type)
{
	//changes level of turret
	Turret5Control.level5 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret5Control.type5 = 1;
	}
	else if(type == "BOMB")
	{
		Turret5Control.type5 = 3;
	}
	else
	{
		Turret5Control.type5 = 2;
	}
}

//change turret 6
function change6(level, type)
{
	//changes level of turret
	Turret6Control.level6 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret6Control.type6 = 1;
	}
	else if(type == "BOMB")
	{
		Turret6Control.type6 = 3;
	}
	else
	{
		Turret6Control.type6 = 2;
	}
}